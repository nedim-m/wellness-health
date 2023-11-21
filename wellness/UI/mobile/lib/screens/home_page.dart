import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/widgets/homepage_button.dart';

class HomepageView extends StatelessWidget {
  const HomepageView({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
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
      ),
      body: Container(
        margin: const EdgeInsets.only(bottom: 100.0),
        child: const Padding(
          padding: EdgeInsets.all(16.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              CustomButton(text: 'Pregled Tretmana'),
              CustomButton(text: 'Moje rezervacije'),
              CustomButton(text: 'Profil'),
              CustomButton(text: 'Odjava'),
            ],
          ),
        ),
      ),
    );
  }
}
