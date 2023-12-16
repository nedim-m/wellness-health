import 'package:flutter/material.dart';

import 'package:mobile/screens/login_page.dart';
import 'package:mobile/screens/profil_page.dart';
import 'package:mobile/screens/treatment_overview_page.dart';
import 'package:mobile/widgets/app_bar.dart';
import 'package:mobile/widgets/custom_button.dart';

class HomepageView extends StatelessWidget {
  const HomepageView({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: Container(
        margin: const EdgeInsets.only(bottom: 100.0),
        child: const Padding(
          padding: EdgeInsets.all(16.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              CustomButton(
                text: 'Pregled Tretmana',
                navigateTo: TreatmentOverview(),
              ),
              CustomButton(
                text: 'Moje rezervacije',
                navigateTo: LoginPageView(),
              ),
              CustomButton(
                text: 'Profil',
                navigateTo: ProfilPageView(),
              ),
              CustomButton(
                text: 'Odjava',
                navigateTo: LoginPageView(),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
