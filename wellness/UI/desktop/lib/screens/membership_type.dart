import 'package:desktop/models/membership_type.dart';
import 'package:desktop/providers/membership_type.provider.dart';
import 'package:flutter/material.dart';

import '../models/search_result.dart';

class MembershipTypePageView extends StatefulWidget {
  const MembershipTypePageView({super.key});

  @override
  State<MembershipTypePageView> createState() => _MembershipTypePageViewState();
}

class _MembershipTypePageViewState extends State<MembershipTypePageView> {
  final MembershipTypeProvider membershipTypeProvider =
      MembershipTypeProvider();
  List<MembershipType> filterData = [];

  SearchResult<MembershipType> myData = SearchResult<MembershipType>();
  MembershipType? selectedMembershipType;

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future<void> fetchData() async {
    myData = await membershipTypeProvider.get();
    setState(() {
      filterData = myData.result;
    });
  }

  void filterMembershipTypes(String value) {
    setState(() {
      myData.result =
          filterData.where((element) => element.name.contains(value)).toList();
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
                    "Select Membership Type: ",
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
                      child: DropdownButton<MembershipType>(
                        value: selectedMembershipType,
                        onChanged: (value) {
                          setState(() {
                            selectedMembershipType = value;
                            filterMembershipTypes(value!.name);
                          });
                        },
                        items: filterData
                            .map(
                              (membershipType) =>
                                  DropdownMenuItem<MembershipType>(
                                value: membershipType,
                                child: Text(membershipType.name),
                              ),
                            )
                            .toList(),
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
                      "Cijena",
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
      DataCell(Text(data.name)),
      DataCell(Text(data.description)),
      DataCell(Text(data.price.toString())),
    ],
  );
}
