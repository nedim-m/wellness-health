import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:mobile/blocs/payment/payment_bloc.dart';
import 'package:mobile/providers/category_provider.dart';
import 'package:mobile/providers/membership_provider.dart';
import 'package:mobile/providers/membership_type_provider.dart';
import 'package:mobile/providers/rating_provider.dart';
import 'package:mobile/providers/reservation_provider.dart';
import 'package:mobile/providers/treatment_provider.dart';
import 'package:mobile/providers/treatment_type_provider.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/login_page.dart';

import 'package:provider/provider.dart';

Future<void> main() async {
  await dotenv.load();
  WidgetsFlutterBinding.ensureInitialized();
  Stripe.publishableKey = dotenv.env['STRIPE_PUBLISHABLE_KEY']!;
  await Stripe.instance.applySettings();
  
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => TreatmentProvider()),
      ChangeNotifierProvider(create: (_) => TreatmentTypeProvider()),
      ChangeNotifierProvider(create: (_) => CategoryProvider()),
      ChangeNotifierProvider(create: (_) => ReservationProvider()),
      ChangeNotifierProvider(create: (_) => RatingProvider()),
      ChangeNotifierProvider(create: (_) => UserProvider()),
      ChangeNotifierProvider(create: (_) => MembershipProvider()),
      ChangeNotifierProvider(create: (_) => MembershipTypeProvider()),
    ],
    child: MultiBlocProvider(
      providers: [
        BlocProvider(
          create: (context) => PaymentBloc(),
        ),
      ],
      child: const MyApp(),
    ),
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
