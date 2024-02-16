import 'dart:io';

import 'package:desktop/models/membership_type.dart';
import 'package:desktop/models/report.dart';
import 'package:desktop/models/search_result.dart';
import 'package:desktop/providers/membership_type.provider.dart';
import 'package:desktop/providers/report_provider.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:open_file/open_file.dart' as open_file;

import 'package:pdf/widgets.dart' as pw;

class ReportShowWidget extends StatefulWidget {
  const ReportShowWidget({Key? key});

  @override
  State<ReportShowWidget> createState() => _ReportShowWidgetState();
}

class _ReportShowWidgetState extends State<ReportShowWidget> {
  final ReportProvider _reportProvider = ReportProvider();
  List<Report> filterData = [];

  MembershipType? selectedMembershipType;
  final MembershipTypeProvider membershipTypeProvider =
      MembershipTypeProvider();

  SearchResult<Report> myData = SearchResult<Report>();
  SearchResult<MembershipType> filterDataMembership =
      SearchResult<MembershipType>();

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future<void> fetchData() async {
    myData = await _reportProvider.get();
    filterDataMembership = await membershipTypeProvider.get();
    setState(() {
      filterData = myData.result;
    });
  }

  void filterMembershipTypes(String value) {
    setState(() {
      myData.result = filterData
          .where((element) =>
              element.memberShipTypeId == selectedMembershipType?.id)
          .toList();
    });
  }

  Future<void> generatePDF(Report report) async {
    final pdf = pw.Document();

    pdf.addPage(
      pw.Page(
        build: (pw.Context context) => pw.Column(
          crossAxisAlignment: pw.CrossAxisAlignment.start,
          children: [
            pw.Header(
              level: 0,
              child: pw.Text('Izvjestaj o clanarini',
                  style: pw.TextStyle(
                      fontSize: 24, fontWeight: pw.FontWeight.bold)),
            ),
            pw.SizedBox(height: 10),
            pw.Row(
              mainAxisAlignment: pw.MainAxisAlignment.spaceBetween,
              children: [
                pw.Text('Tip clanarine:',
                    style: pw.TextStyle(fontWeight: pw.FontWeight.bold)),
                pw.Text('${report.memberShipTypeName}',
                    style: const pw.TextStyle(fontSize: 16)),
              ],
            ),
            pw.Row(
              mainAxisAlignment: pw.MainAxisAlignment.spaceBetween,
              children: [
                pw.Text('Datum od:',
                    style: pw.TextStyle(fontWeight: pw.FontWeight.bold)),
                pw.Text('${DateFormat('dd.MM.yyyy').format(report.dateFrom)}',
                    style: const pw.TextStyle(fontSize: 16)),
              ],
            ),
            pw.Row(
              mainAxisAlignment: pw.MainAxisAlignment.spaceBetween,
              children: [
                pw.Text('Datum do:',
                    style: pw.TextStyle(fontWeight: pw.FontWeight.bold)),
                pw.Text('${DateFormat('dd.MM.yyyy').format(report.dateTo)}',
                    style: const pw.TextStyle(fontSize: 16)),
              ],
            ),
            pw.Row(
              mainAxisAlignment: pw.MainAxisAlignment.spaceBetween,
              children: [
                pw.Text('Broj korisnika:',
                    style: pw.TextStyle(fontWeight: pw.FontWeight.bold)),
                pw.Text('${report.totalUsers}',
                    style: const pw.TextStyle(fontSize: 16)),
              ],
            ),
            pw.Row(
              mainAxisAlignment: pw.MainAxisAlignment.spaceBetween,
              children: [
                pw.Text('Ukupna zarada:',
                    style: pw.TextStyle(fontWeight: pw.FontWeight.bold)),
                pw.Text('${report.earnedMoney} BAM',
                    style: const pw.TextStyle(fontSize: 16)),
              ],
            ),
          ],
        ),
      ),
    );

    final directory = Directory(
        'C:/Users/Nedim/Documents/GitHub/wellness-health/wellness/UI/desktop/assets/pdf');

    final path = '${directory.path}/report.pdf';

    if (!directory.existsSync()) {
      directory.createSync(recursive: true);
    }

    final file = File(path);
    final pdfBytes = await pdf.save();
    await file.writeAsBytes(pdfBytes);

    try {
      open_file.OpenFile.open(path);
    } catch (error) {
      print('Pogreška pri otvaranju PDF-a: $error');
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
                    "Odaberite tip članarine: ",
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 15,
                    ),
                  ),
                  const SizedBox(width: 10),
                  Expanded(
                    child: Container(
                      padding: const EdgeInsets.symmetric(horizontal: 10),
                      width: 250,
                      height: 40,
                      decoration: BoxDecoration(
                        border: Border.all(color: Colors.grey),
                        borderRadius: BorderRadius.circular(8),
                      ),
                      child: DropdownButton<String>(
                        value: selectedMembershipType?.name,
                        onChanged: (value) {
                          setState(() {
                            selectedMembershipType = filterDataMembership.result
                                .firstWhere((type) => type.name == value);
                            filterMembershipTypes(value!);
                          });
                        },
                        items: filterDataMembership.result
                            .map(
                              (type) => DropdownMenuItem<String>(
                                value: type.name,
                                child: Text(type.name),
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
                      "Tip članarine",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Datum od",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Datum do",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Broj korisnika",
                      style: TextStyle(
                        fontWeight: FontWeight.w600,
                        fontSize: 15,
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Text(
                      "Ukupna zarada",
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
                  generatePDF: generatePDF,
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
  final Function() refreshCallback;
  final Function(Report) generatePDF;
  RowSource({
    required this.myData,
    required this.count,
    required this.context,
    required this.refreshCallback,
    required this.generatePDF,
  });

  @override
  DataRow? getRow(int index) {
    if (index < rowCount) {
      return recentFileDataRow(
          context, myData![index], refreshCallback, generatePDF);
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

DataRow recentFileDataRow(BuildContext context, Report data,
    Function() refreshCallback, Function(Report) generatePDF) {
  final dateFormat = DateFormat('dd.MM.yyyy');
  return DataRow(
    cells: [
      DataCell(Text(data.memberShipTypeName!)),
      DataCell(Text(dateFormat.format(data.dateFrom))),
      DataCell(Text(dateFormat.format(data.dateTo))),
      DataCell(Text(data.totalUsers.toString())),
      DataCell(Text("${data.earnedMoney.toString()} BAM")),
      DataCell(
        ElevatedButton(
          onPressed: () {
            generatePDF(data);
          },
          child: const Text('Generiši PDF'),
        ),
      ),
    ],
  );
}
