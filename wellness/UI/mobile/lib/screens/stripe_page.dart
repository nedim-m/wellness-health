import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/user_provider.dart';
import 'package:mobile/screens/home_page.dart';

import '/blocs/blocs.dart';

class StripePaymentPage extends StatefulWidget {
  const StripePaymentPage({Key? key, required this.memberShipTypeId})
      : super(key: key);
  final int memberShipTypeId;
  @override
  // ignore: library_private_types_in_public_api
  _StripePaymentPageState createState() => _StripePaymentPageState();
}

class _StripePaymentPageState extends State<StripePaymentPage> {
  final UserProvider _userProvider = UserProvider();
  late User loggedUser;

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  Future<void> fetchData() async {
    loggedUser = await _userProvider.getById();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Uplata putem kreditne kartice'),
      ),
      body: BlocBuilder<PaymentBloc, PaymentState>(
        builder: (context, state) {
          CardFormEditController controller = CardFormEditController(
            initialDetails: state.cardFieldInputDetails,
          );

          if (state.status == PaymentStatus.initial) {
            return SingleChildScrollView(
              child: Padding(
                padding: const EdgeInsets.all(20),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  crossAxisAlignment: CrossAxisAlignment.stretch,
                  children: [
                    Text(
                      'Kreditna kartica',
                      style: Theme.of(context).textTheme.headlineSmall,
                    ),
                    const SizedBox(height: 20),
                    CardFormField(controller: controller),
                    const SizedBox(height: 10),
                    ElevatedButton(
                      onPressed: () {
                        (controller.details.complete)
                            ? context.read<PaymentBloc>().add(
                                  PaymentCreateIntent(
                                    billingDetails: BillingDetails(
                                        email: loggedUser.email,
                                        name:
                                            '${loggedUser.firstName} ${loggedUser.lastName}',
                                        phone: loggedUser.phone),
                                    items: widget.memberShipTypeId,
                                  ),
                                )
                            : ScaffoldMessenger.of(context).showSnackBar(
                                const SnackBar(
                                  content: Text('Molim Vas unesite podatke.'),
                                ),
                              );
                      },
                      child: const Text('Plati'),
                    ),
                  ],
                ),
              ),
            );
          }
          if (state.status == PaymentStatus.success) {
            return Container(
              alignment: Alignment.center,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text('Uplata uspješna!'),
                  const SizedBox(
                    height: 10,
                  ),
                  ElevatedButton(
                    onPressed: () {
                      context.read<PaymentBloc>().add(PaymentFinish());
                      Navigator.of(context).pushReplacement(
                        MaterialPageRoute(
                          builder: (context) => const HomepageView(),
                        ),
                      );
                    },
                    child: const Text('Nazad na početnu'),
                  ),
                ],
              ),
            );
          }

          if (state.status == PaymentStatus.failure) {
            return Center(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text('Uplata neuspješna.'),
                  const SizedBox(
                    height: 10,
                  ),
                  ElevatedButton(
                    onPressed: () {
                      context.read<PaymentBloc>().add(PaymentStart());
                    },
                    child: const Text('Pokušajte ponovo.'),
                  ),
                ],
              ),
            );
          } else {
            return const Center(child: CircularProgressIndicator());
          }
        },
      ),
    );
  }
}
