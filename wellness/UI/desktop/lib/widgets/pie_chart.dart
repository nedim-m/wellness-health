import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';

class PieChartDrawer extends StatefulWidget {
  const PieChartDrawer({
    Key? key,
    required this.numOfActive,
    required this.numOfInactive,
    required this.title,
    this.numOfNotAnswered,
  }) : super(key: key);

  final int numOfActive;
  final int numOfInactive;
  final String title;
  final int? numOfNotAnswered;

  @override
  State<PieChartDrawer> createState() => _PieChartDrawerState();
}

class _PieChartDrawerState extends State<PieChartDrawer> {
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Text(widget.title,
            style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
        const SizedBox(height: 8),
        AspectRatio(
          aspectRatio: 1,
          child: PieChart(
            PieChartData(
              sectionsSpace: 0,
              centerSpaceRadius: 40,
              startDegreeOffset: 180,
              sections: [
                PieChartSectionData(
                  color: Colors.blue,
                  value: widget.numOfActive.toDouble(),
                  title: widget.numOfActive.toString(),
                  radius: 50,
                ),
                PieChartSectionData(
                  color: Colors.red,
                  value: widget.numOfInactive.toDouble(),
                  title: widget.numOfInactive.toString(),
                  radius: 50,
                ),
                if (widget.numOfNotAnswered != null)
                  PieChartSectionData(
                    color: Colors.grey,
                    value: widget.numOfNotAnswered!.toDouble(),
                    title: widget.numOfNotAnswered.toString(),
                    radius: 50,
                  ),
              ],
            ),
          ),
        ),
      ],
    );
  }
}
