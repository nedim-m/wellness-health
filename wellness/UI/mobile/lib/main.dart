import 'package:flutter/material.dart';
import 'package:mobile/providers/category_provider.dart';
import 'package:mobile/providers/rating_provider.dart';
import 'package:mobile/providers/reservation_provider.dart';
import 'package:mobile/providers/treatment_provider.dart';
import 'package:mobile/providers/treatment_type_provider.dart';
import 'package:mobile/screens/login_page.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => TreatmentProvider()),
      ChangeNotifierProvider(create: (_) => TreatmentTypeProvider()),
      ChangeNotifierProvider(create: (_) => CategoryProvider()),
      ChangeNotifierProvider(create: (_) => ReservationProvider()),
      ChangeNotifierProvider(create: (_) => RatingProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const LoginPageView(),
    );
  }
}
