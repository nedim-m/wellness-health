import 'package:flutter/material.dart';

class ColorCodedCalendar extends StatelessWidget {
  const ColorCodedCalendar({Key? key});

  @override
  Widget build(BuildContext context) {
    return const Column(
      children: [
        CalendarHeader(),
        CalendarGrid(),
      ],
    );
  }
}

class CalendarHeader extends StatelessWidget {
  const CalendarHeader({Key? key});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: Colors.grey[300],
      child: const Column(
        children: [
          Row(
            children: [
              Expanded(
                flex: 1,
                child: Column(
                  children: [
                    Center(
                      child: Text(
                        'Vrijeme',
                        style: TextStyle(fontWeight: FontWeight.bold),
                      ),
                    ),
                  ],
                ),
              ),
              Expanded(
                flex: 3,
                child: Center(
                  child: Text(
                    "Dostupno",
                    style: TextStyle(fontWeight: FontWeight.bold),
                  ),
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}

class CalendarGrid extends StatelessWidget {
  const CalendarGrid({Key? key});

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Row(
        children: [
          Expanded(
            flex: 1,
            child: Column(
              children: [
                for (int hour = 9; hour <= 19; hour++)
                  Center(
                    child: Text('$hour:00'),
                  ),
              ],
            ),
          ),
          Expanded(
            flex: 3,
            child: Column(
              children: [
                for (int row = 0; row <= 9; row++)
                  Center(
                    child: Container(
                      color: Colors.red,
                    ),
                  ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
