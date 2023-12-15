import 'package:flutter/material.dart';
import 'package:gap/gap.dart';

class ColorCodedCalendar extends StatelessWidget {
  const ColorCodedCalendar({super.key});

  @override
  Widget build(BuildContext context) {
    return const Column(
      children: [
        CalendarHeader(),
        Gap(5),
        CalendarGrid(),
      ],
    );
  }
}

class CalendarHeader extends StatelessWidget {
  const CalendarHeader({
    super.key,
  });

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
  const CalendarGrid({super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        for (int hour = 9; hour <= 19; hour++)
          Row(
            children: [
              Expanded(
                flex: 1,
                child: Center(
                  child: Text('$hour:00'),
                ),
              ),
              Expanded(
                flex: 3,
                child: Center(
                  child: Container(
                    height: 30,
                    decoration: const BoxDecoration(
                      color: Colors.red,
                    ),
                  ),
                ),
              ),
            ],
          ),
        const Gap(15),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [
            _buildLegendSquare(Colors.red),
            const SizedBox(width: 8),
            _buildLegendSquare(Colors.green),
            const SizedBox(width: 8),
            _buildLegendSquare(Colors.yellow),
          ],
        ),
        const Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [
            Text('Zauzeto'),
            SizedBox(width: 8),
            Text('Slobodno'),
            SizedBox(width: 8),
            Text('Pauza'),
          ],
        ),
        const Gap(10),
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () {},
            child: const Text("Rezervisi"),
          ),
        ),
      ],
    );
  }
}

Widget _buildLegendSquare(Color color) {
  return Container(
    width: 20,
    height: 20,
    decoration: BoxDecoration(
      color: color,
    ),
  );
}
