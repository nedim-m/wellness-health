import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_stripe/flutter_stripe.dart';
import 'package:mobile/models/user.dart';
import 'package:mobile/providers/user_provider.dart';

import '/blocs/blocs.dart';

class StripePaymentPage extends StatefulWidget {
  const StripePaymentPage({Key? key}) : super(key: key);

  @override
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
        title: const Text('Pay with a Credit Card'),
      ),
      body: SingleChildScrollView(
        child: BlocBuilder<PaymentBloc, PaymentState>(
          builder: (context, state) {
            CardFormEditController controller = CardFormEditController(
              initialDetails: state.cardFieldInputDetails,
            );

            if (state.status == PaymentStatus.initial) {
              return Padding(
                padding: const EdgeInsets.all(20),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.start,
                  crossAxisAlignment: CrossAxisAlignment.stretch,
                  children: [
                    Text(
                      'Card Form',
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
                                    items: 1,
                                  ),
                                )
                            : ScaffoldMessenger.of(context).showSnackBar(
                                const SnackBar(
                                  content: Text('The form is not complete.'),
                                ),
                              );
                      },
                      child: const Text('Pay'),
                    ),
                  ],
                ),
              );
            }
            if (state.status == PaymentStatus.success) {
              return Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text('The payment is successful.'),
                  const SizedBox(
                    height: 10,
                    width: double.infinity,
                  ),
                  ElevatedButton(
                    onPressed: () {
                      context.read<PaymentBloc>().add(PaymentStart());
                    },
                    child: const Text('Back to Home'),
                  ),
                ],
              );
            }
            if (state.status == PaymentStatus.failure) {
              return Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Text('The payment failed.'),
                  const SizedBox(
                    height: 10,
                    width: double.infinity,
                  ),
                  ElevatedButton(
                    onPressed: () {
                      context.read<PaymentBloc>().add(PaymentStart());
                    },
                    child: const Text('Try again'),
                  ),
                ],
              );
            } else {
              return const Center(child: CircularProgressIndicator());
            }
          },
        ),
      ),
    );
  }
}
