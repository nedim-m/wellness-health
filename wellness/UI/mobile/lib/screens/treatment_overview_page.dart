import 'package:flutter/material.dart';
import 'package:mobile/widgets/app_bar.dart';

class TreatmentOverview extends StatefulWidget {
  const TreatmentOverview({super.key});

  @override
  State<TreatmentOverview> createState() => _TreatmentOverviewState();
}

class _TreatmentOverviewState extends State<TreatmentOverview> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBarWidget(),
    );
  }
}
