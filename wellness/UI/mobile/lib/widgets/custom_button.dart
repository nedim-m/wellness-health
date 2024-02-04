import 'package:flutter/material.dart';

class CustomButton extends StatelessWidget {
  const CustomButton({
    Key? key, 
    required this.text,
    required this.navigateTo,
    this.notificationCount = 0,
  }) : super(key: key); 

  final String text;
  final Widget navigateTo;
  final int notificationCount;

  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      height: 80,
      margin: const EdgeInsets.symmetric(vertical: 8.0),
      child: ElevatedButton(
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => navigateTo),
          );
        },
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Text(text),
            if (notificationCount > 0)
              Container(
                padding: const EdgeInsets.all(8.0),
                decoration: const BoxDecoration(
                  shape: BoxShape.circle,
                  color: Colors.red,
                ),
                child: Text(
                  '$notificationCount',
                  style: const TextStyle(
                    color: Colors.white,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
          ],
        ),
      ),
    );
  }
}
