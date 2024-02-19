import 'package:desktop/models/reservation.dart';
import 'package:desktop/models/search_result.dart';
import 'package:desktop/providers/reservation_provider.dart';
import 'package:flutter/material.dart';

class ReservationPageView extends StatefulWidget {
  const ReservationPageView({super.key});

  @override
  State<ReservationPageView> createState() => _ReservationPageViewState();
}

class _ReservationPageViewState extends State<ReservationPageView> {
  final ReservationProvider _reservationProvider = ReservationProvider();
  List<Reservation> filterData = [];

  SearchResult<Reservation> myData = SearchResult<Reservation>();
  TextEditingController controller = TextEditingController();

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future<void> fetchData() async {
    myData = await _reservationProvider.get();
    setState(() {
      filterData = myData.result;
    });
  }

  Future saveChanges(int id, bool status) async {
    await _reservationProvider.updateStatus(id, status);
  }

  Future<bool?> _showConfirmationDialog(
      BuildContext context, String message) async {
    return await showDialog<bool>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text("Potvrda"),
          content: Text(message),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop(true);
              },
              child: const Text("DA"),
            ),
            TextButton(
              onPressed: () {
                Navigator.of(context).pop(false);
              },
              child: const Text("NE"),
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 20),
            Container(
              width: 500,
              padding: const EdgeInsets.all(10),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  const Text(
                    "Datum (dd.mm.yyyy) : ",
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 15,
                    ),
                  ),
                  const SizedBox(width: 10),
                  Expanded(
                    child: Container(
                      width: 250,
                      height: 40,
                      decoration: BoxDecoration(
                        border: Border.all(color: Colors.grey),
                        borderRadius: BorderRadius.circular(8),
                      ),
                      child: TextField(
                        controller: controller,
                        decoration: const InputDecoration(
                          focusedBorder: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.blue)),
                          contentPadding:
                              EdgeInsets.symmetric(vertical: 8, horizontal: 10),
                          border: InputBorder.none,
                          prefixIcon: Icon(Icons.search),
                        ),
                        style: const TextStyle(fontSize: 14),
                        onChanged: (value) {
                          setState(() {
                            myData.result = filterData
                                .where(
                                    (element) => element.date.contains(value))
                                .toList();
                          });
                        },
                      ),
                    ),
                  ),
                ],
              ),
            ),
            const SizedBox(height: 10),
            SizedBox(
              width: double.infinity,
              child: PaginatedDataTable(
                columns: const [
                  DataColumn(
                    label: Text(
                      "Tretman",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Ime",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Prezime",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Broj telefona",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Datum i vrijeme",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Status",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Akcija",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                ],
                source: RowSource(
                  saveChanges,
                  _showConfirmationDialog,
                  count: myData.result.length,
                  myData: myData.result,
                  context: context,
                  refreshCallback: fetchData,
                ),
                rowsPerPage: 5,
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class RowSource extends DataTableSource {
  final dynamic myData;
  final int count;
  final BuildContext context;
  final Function(int id, bool status) saveChanges;
  final Function(BuildContext context, String message) _showConfirmationDialog;

  final Function() refreshCallback;
  RowSource(
    this.saveChanges,
    this._showConfirmationDialog, {
    required this.myData,
    required this.count,
    required this.context,
    required this.refreshCallback,
  });

  @override
  DataRow? getRow(int index) {
    if (index < rowCount) {
      return recentFileDataRow(context, myData![index], saveChanges,
          _showConfirmationDialog, refreshCallback);
    } else {
      return null;
    }
  }

  @override
  bool get isRowCountApproximate => false;

  @override
  int get rowCount => count;

  @override
  int get selectedRowCount => 0;
}

Widget _buildStatusIcon(bool? status) {
  if (status == null) {
    return const Icon(Icons.access_time, color: Colors.grey);
  } else if (status == true) {
    return const Icon(Icons.check, color: Colors.green);
  } else {
    return const Icon(Icons.close, color: Colors.red);
  }
}

DataRow recentFileDataRow(
    BuildContext context,
    data,
    Function(int id, bool status) saveChanges,
    Function(BuildContext context, String message) showConfirmationDialog,
    Function() refreshCallback) {
  return DataRow(
    cells: [
      DataCell(Text(data.treatment)),
      DataCell(Text(data.firstName)),
      DataCell(Text(data.lastName)),
      DataCell(Text(data.phone)),
      DataCell(Text("${data.date} u ${data.time}")),
      DataCell(_buildStatusIcon(data.status)),
      DataCell(
        Row(
          children: [
            Expanded(
              child: ElevatedButton(
                onPressed: data.status != null
                    ? null
                    : () async {
                        bool? acceptReservation = await showConfirmationDialog(
                          context,
                          "Da li ste sigurni da želite prihvatiti ovu rezervaciju?",
                        );

                        if (acceptReservation != null && acceptReservation) {
                          await saveChanges(data.id, true);
                          refreshCallback();
                        }
                      },
                child: const Text("Prihvati"),
              ),
            ),
            const SizedBox(width: 8),
            Expanded(
              child: ElevatedButton(
                onPressed: data.status != null
                    ? null
                    : () async {
                        bool? rejectReservation = await showConfirmationDialog(
                          context,
                          "Da li ste sigurni da želite odbiti ovu rezervaciju?",
                        );

                        if (rejectReservation != null && rejectReservation) {
                          await saveChanges(data.id, false);
                          refreshCallback();
                        }
                      },
                child: const Text("Odbij"),
              ),
            ),
          ],
        ),
      ),
    ],
  );
}
