import 'package:flutter/material.dart';
import 'package:mobile/screens/home_page.dart';

class PaypalFinishPage extends StatelessWidget {
  const PaypalFinishPage({super.key});
  

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Uplata putem PayPala'),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const Text('Uplata uspješna!'),
          const SizedBox(
            height: 10,
            width: double.infinity,
          ),
          ElevatedButton(
            onPressed: () {
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
}
