import 'package:desktop/providers/category_provider.dart';
import 'package:desktop/providers/membership_provider.dart';
import 'package:desktop/providers/membership_type.provider.dart';
import 'package:desktop/providers/record_provider.dart';
import 'package:desktop/providers/report_provider.dart';
import 'package:desktop/providers/reservation_provider.dart';
import 'package:desktop/providers/role_provider.dart';
import 'package:desktop/providers/shift_provider.dart';
import 'package:desktop/providers/treatment_provider.dart';
import 'package:desktop/providers/treatment_type_provider.dart';

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
      ChangeNotifierProvider(create: (_) => RoleProvider()),
      ChangeNotifierProvider(create: (_) => ReservationProvider()),
      ChangeNotifierProvider(create: (_) => ReportProvider()),
      ChangeNotifierProvider(create: (_) => ShiftProvider()),
      ChangeNotifierProvider(create: (_) => MembershipProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

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
