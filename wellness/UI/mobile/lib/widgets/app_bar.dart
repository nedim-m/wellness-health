import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
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
        final String? _fullName = snapshot.data;

        return AppBar(
          title: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              const Text('Wellness Center - Health'),
              const Gap(10),
              Text(
                'Dobro došli, $_fullName',
                style: const TextStyle(fontSize: 16.0),
              ),
            ],
          ),
          centerTitle: true,
        );
      },
    );
  }
}
