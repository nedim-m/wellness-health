import 'package:flutter/material.dart';

class DoubleTextWidget extends StatelessWidget {
  const DoubleTextWidget(
      {super.key, required this.bigText, required this.smallText});

  final String bigText;
  final String smallText;

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.start,
      crossAxisAlignment: CrossAxisAlignment.end,
      children: [
        Text(
          bigText,
          style: const TextStyle(
            fontWeight: FontWeight.bold,
            fontSize: 18,
          ),
        ),
        Text(
          smallText,
          style: const TextStyle(
            fontSize: 16,
          ),
        ),
      ],
    );
  }
}
