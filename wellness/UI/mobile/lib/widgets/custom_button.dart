import 'package:flutter/material.dart';
import 'package:mobile/utils/app_styles.dart';

class CustomButton extends StatelessWidget {
  const CustomButton({
    Key? key,
    required this.text,
    required this.navigateTo,
    this.notificationCount = 0,
    this.onPressedCustom,
  }) : super(key: key);

  final String text;
  final Widget navigateTo;
  final int notificationCount;
  final VoidCallback? onPressedCustom;

  @override
  Widget build(BuildContext context) {
    return Container(
      width: double.infinity,
      height: 80,
      margin: const EdgeInsets.symmetric(vertical: 8.0),
      child: ElevatedButton(
        style: ElevatedButton.styleFrom(
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(0),
          ),
          backgroundColor: Styles.primaryColor,
        ),
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => navigateTo),
          );

          if (onPressedCustom != null) {
            onPressedCustom!();
          }
        },
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Text(
              text,
              style: Styles.headLineStyle4.copyWith(color: Colors.white),
            ),
            if (notificationCount > 0) ...[
              const SizedBox(width: 8.0),
              _buildNotificationIndicator(),
            ],
          ],
        ),
      ),
    );
  }

  Widget _buildNotificationIndicator() {
    return Container(
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
    );
  }
}
