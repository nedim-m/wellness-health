import 'package:flutter/material.dart';
import 'package:gap/gap.dart';

class AppBarWidget extends StatelessWidget implements PreferredSizeWidget {
  const AppBarWidget({super.key});
  @override
  Size get preferredSize => const Size.fromHeight(kToolbarHeight);

  @override
  Widget build(BuildContext context) {
    return AppBar(
      title: const Column(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          Text('Wellness Center - Health'),
          Gap(10),
          Text(
            'Dobro došli, Ime i Prezime',
            style: TextStyle(fontSize: 16.0),
          ),
        ],
      ),
      centerTitle: true,
    );
  }
}
