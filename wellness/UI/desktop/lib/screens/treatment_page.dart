import 'package:desktop/models/treatment.dart';
import 'package:desktop/providers/treatment_provider.dart';
import 'package:flutter/material.dart';

import '../models/search_result.dart';
import '../popups/treatment_detail_widget.dart';
import '../popups/treatment_upsert_popup.dart';
import '../widgets/bottom_right_button.dart';

class TreatmentPageView extends StatefulWidget {
  const TreatmentPageView({super.key});

  @override
  State<TreatmentPageView> createState() => _TreatmentPageViewState();
}

class _TreatmentPageViewState extends State<TreatmentPageView> {
  final TreatmentProvider _treatmentProvider = TreatmentProvider();
  List<Treatment> filterData = [];

  SearchResult<Treatment> myData = SearchResult<Treatment>();
  TextEditingController treatmentTypeController = TextEditingController();
  TextEditingController categoryController = TextEditingController();

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future fetchData() async {
    myData = await _treatmentProvider.get();
    setState(() {
      filterData = myData.result;
    });
  }

  Future<bool> deleteData(int id) async {
    try {
      bool success = await _treatmentProvider.delete(id);

      if (success) {
        fetchData();
      }

      return success;
    } catch (e) {
      return false;
    }
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
              child: Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.start,
                    children: [
                      const Text(
                        "Unesite vrstu uslugu ",
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
                            controller: treatmentTypeController,
                            decoration: const InputDecoration(
                              focusedBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.blue),
                              ),
                              contentPadding: EdgeInsets.symmetric(
                                vertical: 8,
                                horizontal: 10,
                              ),
                              border: InputBorder.none,
                              prefixIcon: Icon(Icons.search),
                            ),
                            style: const TextStyle(fontSize: 14),
                            onChanged: (value) {
                              setState(() {
                                myData.result = filterData
                                    .where((element) =>
                                        element.treatmentType.contains(value))
                                    .toList();
                              });
                            },
                          ),
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 15),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.start,
                    children: [
                      const Text(
                        "Unesite kategoriju ",
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
                            controller: categoryController,
                            decoration: const InputDecoration(
                              focusedBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.blue),
                              ),
                              contentPadding: EdgeInsets.symmetric(
                                vertical: 8,
                                horizontal: 10,
                              ),
                              border: InputBorder.none,
                              prefixIcon: Icon(Icons.search),
                            ),
                            style: const TextStyle(fontSize: 14),
                            onChanged: (value) {
                              setState(() {
                                myData.result = filterData
                                    .where((element) =>
                                        element.category.contains(value))
                                    .toList();
                              });
                            },
                          ),
                        ),
                      ),
                    ],
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
                      "Naziv",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Vrsta usluge",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Kategorija",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Trajanje",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Opis",
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
                  count: myData.result.length,
                  myData: myData.result,
                  context: context,
                  refreshCallback: fetchData,
                  deleteCallback: deleteData,
                ),
                rowsPerPage: 5,
              ),
            ),
            BottomRightButton(
              buttonText: "Dodaj",
              onPressed: () async {
                showDialog(
                  context: context,
                  builder: (context) {
                    return TreatmenUpsertPopUpWidget(
                      edit: false,
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

class TreatmenUpsertPopUpWidgetState {}

class RowSource extends DataTableSource {
  final dynamic myData;
  final int count;
  final BuildContext context;
  final Function() refreshCallback;
  final Function(int) deleteCallback;
  RowSource(
      {required this.myData,
      required this.count,
      required this.context,
      required this.refreshCallback,
      required this.deleteCallback});

  @override
  DataRow? getRow(int index) {
    if (index < rowCount) {
      return recentFileDataRow(
          context, myData![index], refreshCallback, deleteCallback);
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

DataRow recentFileDataRow(BuildContext context, var data,
    Function() refreshCallback, Function(int) deleteCallback) {
  return DataRow(
    cells: [
      DataCell(Text(data.name)),
      DataCell(Text(data.treatmentType)),
      DataCell(Text(data.category)),
      DataCell(Text("${data.duration} minuta")),
      DataCell(
        SizedBox(
          width: 150,
          child: Tooltip(
            message: data.description,
            child: Text(
              data.description,
              overflow: TextOverflow.ellipsis,
              maxLines: 1,
            ),
          ),
        ),
      ),
      DataCell(
        Row(
          children: [
            Expanded(
              child: ElevatedButton(
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) {
                      return TreatmentDetailWidget(
                        data: data,
                      );
                    },
                  );
                },
                child: const Text("Details"),
              ),
            ),
            const SizedBox(width: 8),
            Expanded(
              child: ElevatedButton(
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) {
                      return TreatmenUpsertPopUpWidget(
                        data: data,
                        edit: true,
                        refreshCallback: refreshCallback,
                      );
                    },
                  );
                },
                child: const Text("Edit"),
              ),
            ),
            const SizedBox(width: 8),
            Expanded(
              child: ElevatedButton(
                onPressed: () async {
                  bool deleted = await deleteCallback(data.id);
                  if (!deleted) {
                    // ignore: use_build_context_synchronously
                    showDialog(
                      context: context,
                      builder: (context) {
                        return AlertDialog(
                          title: const Text(
                            'Deletion Error',
                            style: TextStyle(color: Colors.red),
                          ),
                          content: const Text('You cannot delete this item.'),
                          actions: <Widget>[
                            TextButton(
                              child: const Text('OK'),
                              onPressed: () {
                                Navigator.of(context).pop();
                              },
                            ),
                          ],
                        );
                      },
                    );
                  }
                },
                child: const Text("Delete"),
              ),
            ),
          ],
        ),
      ),
    ],
  );
}
