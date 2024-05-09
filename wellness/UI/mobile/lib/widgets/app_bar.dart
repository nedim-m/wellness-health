import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/utils/app_styles.dart';
import 'package:mobile/utils/user_store.dart';

class AppBarWidget extends StatelessWidget implements PreferredSizeWidget {
  const AppBarWidget({Key? key}) : super(key: key);

  @override
  Size get preferredSize => const Size.fromHeight(kToolbarHeight);

  @override
  Widget build(BuildContext context) {
    return FutureBuilder<String?>(
      future: UserManager.getFullNameAsync(),
      builder: (context, snapshot) {
        final String? fullName = snapshot.data;

        return AppBar(
          backgroundColor: Styles.primaryColor,
          title: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              Text(
                'Wellness Center - Health',
                style: Styles.headLineStyle2.copyWith(color: Styles.kakiColor),
              ),
              const Gap(10),
              Text(
                'Dobro došli, $fullName',
                style: Styles.headLineStyle3.copyWith(color: Colors.white),
              ),
            ],
          ),
          centerTitle: true,
        );
      },
    );
  }
}
