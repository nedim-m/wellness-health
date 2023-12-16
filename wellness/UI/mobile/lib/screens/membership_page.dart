import 'package:flutter/material.dart';
import 'package:mobile/widgets/app_bar.dart';

class MembershipPageView extends StatefulWidget {
  const MembershipPageView({super.key});

  @override
  State<MembershipPageView> createState() => _MembershipPageViewState();
}

class _MembershipPageViewState extends State<MembershipPageView> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(),
    );
  }
}
