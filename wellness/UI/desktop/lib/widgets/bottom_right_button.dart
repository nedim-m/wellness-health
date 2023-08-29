import 'package:flutter/material.dart';

class BottomRightButton extends StatelessWidget {
  const BottomRightButton(
      {super.key, required this.buttonText, required this.onPressed});
  final String buttonText;
  final VoidCallback onPressed;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(0, 10, 20, 20),
      child: Align(
        alignment: Alignment.bottomRight,
        child: ElevatedButton(
          onPressed: onPressed,
          child: Text(buttonText),
        ),
      ),
    );
  }
}
