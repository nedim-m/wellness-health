import 'package:flutter/material.dart';
import 'package:mobile/widgets/app_bar.dart';

class CCPageView extends StatelessWidget {
  const CCPageView({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppBarWidget(),
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              const SizedBox(height: 20),
              const Center(
                child: Text(
                  'Uplata putem kartice',
                  style: TextStyle(
                    fontSize: 24,
                    fontWeight: FontWeight.bold,
                    color: Colors.blue,
                  ),
                ),
              ),
              const SizedBox(height: 30),
              const Text(
                'Card Number',
                style: TextStyle(fontSize: 16),
              ),
              const SizedBox(height: 8),
              const TextField(
                keyboardType: TextInputType.number,
                decoration: InputDecoration(
                  hintText: 'Unesite broj kartice',
                  border: OutlineInputBorder(),
                ),
              ),
              const SizedBox(height: 16),
              const Text(
                'Datum isteka',
                style: TextStyle(fontSize: 16),
              ),
              const SizedBox(height: 8),
              const Row(
                children: [
                  Expanded(
                    child: TextField(
                      keyboardType: TextInputType.number,
                      decoration: InputDecoration(
                        hintText: 'MM',
                        border: OutlineInputBorder(),
                      ),
                    ),
                  ),
                  SizedBox(width: 16),
                  Expanded(
                    child: TextField(
                      keyboardType: TextInputType.number,
                      decoration: InputDecoration(
                        hintText: 'YY',
                        border: OutlineInputBorder(),
                      ),
                    ),
                  ),
                ],
              ),
              const SizedBox(height: 16),
              const Text(
                'CVV',
                style: TextStyle(fontSize: 16),
              ),
              const SizedBox(height: 8),
              const TextField(
                keyboardType: TextInputType.number,
                decoration: InputDecoration(
                  hintText: 'Unesi CVV',
                  border: OutlineInputBorder(),
                ),
              ),
              const SizedBox(height: 32),
              SizedBox(
                width: double.infinity,
                child: ElevatedButton(
                  onPressed: () {},
                  child: const Text('Uplati'),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
