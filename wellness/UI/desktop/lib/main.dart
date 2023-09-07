import 'package:desktop/providers/category_provider.dart';
import 'package:desktop/providers/membership_type.provider.dart';
import 'package:desktop/providers/record_provider.dart';
import 'package:desktop/providers/treatment_provider.dart';
import 'package:desktop/providers/treatment_type_provider.dart';
import 'package:desktop/providers/treatment_upsert_provider.dart';
import 'package:desktop/providers/user_provider.dart';
import 'package:desktop/screens/login_page.dart';
import 'package:fluent_ui/fluent_ui.dart';

import 'package:provider/provider.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => CategoryProvider()),
      ChangeNotifierProvider(create: (_) => UserProvider()),
      ChangeNotifierProvider(create: (_) => TreatmentTypeProvider()),
      ChangeNotifierProvider(create: (_) => MembershipTypeProvider()),
      ChangeNotifierProvider(create: (_) => RecordProvider()),
      ChangeNotifierProvider(create: (_) => TreatmentProvider()),
      ChangeNotifierProvider(create: (_) => TreatmentUpsertProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return FluentApp(
      debugShowCheckedModeBanner: false,
      theme: FluentThemeData(
        accentColor: Colors.blue,
      ),
      home: const LoginPageView(),
    );
  }
}
