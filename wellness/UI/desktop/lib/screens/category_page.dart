import 'package:desktop/providers/category_provider.dart';
import 'package:flutter/material.dart';

import '../models/category.dart';
import '../models/search_result.dart';
import '../popups/category_upsert_popup.dart';

import '../widgets/bottom_right_button.dart';

class CategoryPageView extends StatefulWidget {
  const CategoryPageView({super.key});

  @override
  State<CategoryPageView> createState() => _CategoryPageViewState();
}

class _CategoryPageViewState extends State<CategoryPageView> {
  final CategoryProvider _categoryProvider = CategoryProvider();
  List<Category> filterData = [];

  SearchResult<Category> myData = SearchResult<Category>();
  TextEditingController controller = TextEditingController();

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future fetchData() async {
    myData = await _categoryProvider.get();
    setState(() {
      filterData = myData.result;
    });
  }

  Future<bool> deleteData(int id) async {
    try {
      bool success = await _categoryProvider.delete(id);

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
              child: Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [
                  const Text(
                    "Unesite naziv kategorije: ",
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
                                    (element) => element.name.contains(value))
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
                      "Naziv",
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
                    return CategoryEditPopUpWidget(
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
      DataCell(Text(data.name ?? "Name")),
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
                      return CategoryEditPopUpWidget(
                        data: data,
                        edit: true,
                        refreshCallback: refreshCallback,
                      );
                    },
                  );
                },
                child: const Text("Ažuriraj"),
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
                            'Greška prilikom brisanja',
                            style: TextStyle(color: Colors.red),
                          ),
                          content:
                              const Text('Ne možete obrisati ovu kategoriju.'),
                          actions: <Widget>[
                            TextButton(
                              child: const Text('Uredu'),
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
                child: const Text("Obriši"),
              ),
            ),
          ],
        ),
      ),
    ],
  );
}
