import 'package:desktop/providers/user_provider.dart';

import 'package:flutter/material.dart';

import '../models/search_result.dart';
import '../models/user.dart';

class WorkerPageView extends StatefulWidget {
  const WorkerPageView({super.key});

  @override
  State<WorkerPageView> createState() => _WorkerPageViewState();
}

class _WorkerPageViewState extends State<WorkerPageView> {
  final UserProvider _userProvider = UserProvider();
  List<User> filterData = [];

  SearchResult<User> myData = SearchResult<User>();
  TextEditingController controller = TextEditingController();

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future fetchData() async {
    myData = await _userProvider.get(filter: {'role': "notmember"});
    setState(() {
      filterData = myData.result;
    });
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
                    "Unesite ime zaposlenika: ",
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
                      "Radno vrijeme",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Aktivan",
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
                ),
                rowsPerPage: 8,
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
      DataCell(Text(data.firstName)),
      DataCell(Text(data.lastName)),
      DataCell(Text(data.shiftTime)),
      DataCell(
        Text(
          data.status ? "DA" : "NE",
        ),
      ),
    ],
  );
}