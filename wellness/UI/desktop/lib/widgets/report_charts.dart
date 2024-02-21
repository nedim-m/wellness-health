import 'package:desktop/providers/report_provider.dart';
import 'package:desktop/widgets/pie_chart.dart';
import 'package:flutter/material.dart';

class ReportCharts extends StatefulWidget {
  const ReportCharts({Key? key}) : super(key: key);

  @override
  State<ReportCharts> createState() => _ReportChartsState();
}

class _ReportChartsState extends State<ReportCharts> {
  late Map<String, dynamic> reportUsers;
  late Map<String, dynamic> reportReservations;
  late Map<String, dynamic> reportMemberships;
  final ReportProvider _reportProvider = ReportProvider();

  @override
  void initState() {
    super.initState();
    reportUsers = {'active': 0, 'inactive': 0, 'notAnswered': 0};
    reportReservations = {'active': 0, 'inactive': 0, 'notAnswered': 0};
    reportMemberships = {'active': 0, 'inactive': 0};
    fetchData().then((_) {
      setState(() {});
    });
  }

  Future<void> fetchData() async {
    reportUsers = await _reportProvider.getNumUsers();
    reportReservations = await _reportProvider.getNumReservations();
    reportMemberships = await _reportProvider.getNumMemberships();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: Column(
          children: [
            const SizedBox(height: 30),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                ConstrainedBox(
                    constraints:
                        const BoxConstraints(maxWidth: 300, maxHeight: 400),
                    child: PieChartDrawer(
                      numOfActive: reportUsers['active'],
                      numOfInactive: reportUsers['inactive'],
                      title: 'Korisnici',
                    )),
                ConstrainedBox(
                    constraints:
                        const BoxConstraints(maxWidth: 300, maxHeight: 400),
                    child: PieChartDrawer(
                      numOfActive: reportReservations['active'],
                      numOfInactive: reportReservations['inactive'],
                      numOfNotAnswered: reportReservations['notAnswered'] ?? 0,
                      title: 'Rezervacije',
                    )),
                ConstrainedBox(
                    constraints:
                        const BoxConstraints(maxWidth: 300, maxHeight: 400),
                    child: PieChartDrawer(
                      numOfActive: reportMemberships['active'],
                      numOfInactive: reportMemberships['inactive'],
                      title: 'Članarine',
                    )),
              ],
            ),
            _buildLegend()
          ],
        ),
      ),
    );
  }

  Widget _buildLegend() {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        _buildLegendItem(Colors.blue, 'Aktivni'),
        const SizedBox(width: 10),
        _buildLegendItem(Colors.red, 'Neaktivni'),
        const SizedBox(width: 10),
        _buildLegendItem(Colors.grey, 'Neodgovoreni'),
      ],
    );
  }

  Widget _buildLegendItem(Color color, String text) {
    return Row(
      children: [
        Container(
          width: 20,
          height: 20,
          decoration: BoxDecoration(
            shape: BoxShape.rectangle,
            color: color,
          ),
        ),
        const SizedBox(width: 5),
        Text(text),
      ],
    );
  }
}
