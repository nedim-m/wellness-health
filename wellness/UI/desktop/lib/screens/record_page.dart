import 'package:desktop/models/record.dart';
import 'package:desktop/popups/record_add_popup.dart';
import 'package:desktop/providers/record_provider.dart';

import 'package:flutter/material.dart';

import '../models/search_result.dart';
import '../widgets/bottom_right_button.dart';

class RecordPageView extends StatefulWidget {
  const RecordPageView({super.key});

  @override
  State<RecordPageView> createState() => _RecordPageViewState();
}

class _RecordPageViewState extends State<RecordPageView> {
  final RecordProvider _recordProvider = RecordProvider();
  List<Records> filterData = [];

  SearchResult<Records> myData = SearchResult<Records>();
  TextEditingController controller = TextEditingController();

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future fetchData() async {
    myData = await _recordProvider.get(filter: {'prisutni': 'DA'});
    setState(() {
      filterData = myData.result;
    });
  }

  Future leaveEntry(dynamic user) async {
    await _recordProvider.leaveEntry(user);
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
                    "Unesite ime prisutnog korisnika: ",
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
                                .where((element) =>
                                    element.firstName.contains(value))
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
                      "Korisničko ime",
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
                      "Vrijeme ulaska",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Evidentiraj izlaz",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                ],
                source: RowSource(
                  leaveEntry,
                  count: myData.result.length,
                  myData: myData.result,
                  context: context,
                  refreshCallback: fetchData,
                ),
                rowsPerPage: 5,
              ),
            ),
            BottomRightButton(
              buttonText: "Evidentiraj ulaz",
              onPressed: () async {
                showDialog(
                  context: context,
                  builder: (context) {
                    return RecordAddPopupWidget(
                      refreshCallback: fetchData,
                    );
                  },
                );
              },
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
  final Function(dynamic) leaveEntry;
  final Function() refreshCallback;
  RowSource(
    this.leaveEntry, {
    required this.myData,
    required this.count,
    required this.context,
    required this.refreshCallback,
  });

  @override
  DataRow? getRow(int index) {
    if (index < rowCount) {
      return recentFileDataRow(
          context, myData![index], leaveEntry, refreshCallback);
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

DataRow recentFileDataRow(BuildContext context, data,
    Function(dynamic) leaveEntry, Function() refreshCallback) {
  return DataRow(
    cells: [
      DataCell(Text(data.firstName)),
      DataCell(Text(data.lastName)),
      DataCell(Text(data.userName)),
      DataCell(Text(data.phone)),
      DataCell(Text(data.entryDate.toString())),
      DataCell(
        Row(
          children: [
            Expanded(
              child: ElevatedButton(
                onPressed: () async {
                  await leaveEntry(data);
                  refreshCallback();
                },
                child: const Text("Izlaz"),
              ),
            ),
          ],
        ),
      ),
    ],
  );
}
