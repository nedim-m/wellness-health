import 'package:desktop/providers/user_provider.dart';

import 'package:flutter/material.dart';

import '../models/search_result.dart';
import '../models/user.dart';

import '../popups/worker_upsert_popup.dart';
import '../widgets/bottom_right_button.dart';

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

  Future<void> fetchData() async {
    try {
      myData = await _userProvider.get(filter: {'role': 'notmember'});

      if (mounted) {
        setState(() {
          filterData = myData.result;
        });
      }
    } catch (e) {
      print('Error fetching data: $e');
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
                    return WorkerEditPopUpWidget(
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
  RowSource({
    required this.myData,
    required this.count,
    required this.context,
    required this.refreshCallback,
  });

  @override
  DataRow? getRow(int index) {
    if (index < rowCount) {
      return recentFileDataRow(context, myData![index], refreshCallback);
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

DataRow recentFileDataRow(
    BuildContext context, var data, Function() refreshCallback) {
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
      DataCell(
        Row(
          children: [
            Expanded(
              child: ElevatedButton(
                onPressed: () async {
                  await showDialog(
                    context: context,
                    builder: (context) {
                      return WorkerEditPopUpWidget(
                        edit: true,
                        data: data,
                        refreshCallback: refreshCallback,
                      );
                    },
                  );
                },
                child: const Text("Edit"),
              ),
            ),
          ],
        ),
      ),
    ],
  );
}
