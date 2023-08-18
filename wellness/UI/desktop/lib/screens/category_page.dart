import 'package:desktop/providers/category_provider.dart';
import 'package:flutter/material.dart';

import '../models/category.dart';
import '../models/search_result.dart';

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

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Container(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              SizedBox(
                width: double.infinity,
                //height: double.infinity,
                child: PaginatedDataTable(
                  header: Container(
                    //input field
                    padding: const EdgeInsets.all(5),
                    decoration: BoxDecoration(
                        border: Border.all(
                          color: Colors.grey,
                        ),
                        borderRadius: BorderRadius.circular(12)),
                    child: TextField(
                      controller: controller,
                      decoration: const InputDecoration(
                          hintText: "Unesite ime korisnika"),
                      onChanged: (value) {
                        setState(() {
                          myData.result = filterData
                              .where((element) => element.name.contains(value))
                              .toList();
                        });
                      },
                    ),
                  ),
                  columns: const [
                    DataColumn(
                      label: Text(
                        "Id",
                        style: TextStyle(
                            fontWeight: FontWeight.w600, fontSize: 14),
                      ),
                    ),
                    DataColumn(
                      label: Text(
                        "Naziv",
                        style: TextStyle(
                            fontWeight: FontWeight.w600, fontSize: 14),
                      ),
                    ),
                    DataColumn(
                      label: Text(
                        "Opis",
                        style: TextStyle(
                            fontWeight: FontWeight.w600, fontSize: 14),
                      ),
                    ),
                    DataColumn(
                      label: Text(
                        "Status",
                        style: TextStyle(
                            fontWeight: FontWeight.w600, fontSize: 14),
                      ),
                    ),
                  ],
                  source: RowSource(
                      count: myData.result.length, myData: myData.result),
                  rowsPerPage: 8,
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}

class RowSource extends DataTableSource {
  final dynamic myData;
  final int count;
  RowSource({
    required this.myData,
    required this.count,
  });

  @override
  DataRow? getRow(int index) {
    if (index < rowCount) {
      return recentFileDataRow(myData![index]);
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

DataRow recentFileDataRow(var data) {
  return DataRow(
    cells: [
      DataCell(Text(data.id.toString())),
      DataCell(Text(data.name ?? "Name")),
      DataCell(Text(data.description)),
      DataCell(Text(data.status.toString())),
    ],
  );
}
