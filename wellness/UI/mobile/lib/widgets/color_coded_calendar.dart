import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:mobile/providers/reservation_provider.dart';
import 'package:provider/provider.dart';

class ColorCodedCalendar extends StatefulWidget {
  const ColorCodedCalendar({
    Key? key,
    required this.treatmentId,
    required this.selectedDate,
  }) : super(key: key);

  final int treatmentId;
  final DateTime selectedDate;

  @override
  State<ColorCodedCalendar> createState() => _ColorCodedCalendarState();
}

class _ColorCodedCalendarState extends State<ColorCodedCalendar> {
  int? selectedHour;

  void _addReservation() async {
    if (selectedHour != null) {
      final provider = Provider.of<ReservationProvider>(context, listen: false);
      await provider.addReservation(
        1,
        widget.selectedDate,
        '$selectedHour:00',
        widget.treatmentId,
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: [
          const CalendarHeader(),
          const Gap(5),
          CalendarGrid(
            selectedHour: selectedHour,
            onHourSelected: (hour) {
              setState(() {
                selectedHour = hour;
              });
            },
            addReservation: _addReservation,
          ),
        ],
      ),
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
  final int? selectedHour;
  final ValueChanged<int>? onHourSelected;
  final VoidCallback? addReservation;

  const CalendarGrid({
    Key? key,
    this.selectedHour,
    this.onHourSelected,
    this.addReservation,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        for (int hour = 9; hour <= 19; hour++)
          HourRow(
            hour: hour,
            isSelected: selectedHour == hour,
            onHourSelected: onHourSelected,
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
            onPressed: addReservation,
            child: const Text("Rezervisi"),
          ),
        ),
      ],
    );
  }
}

class HourRow extends StatelessWidget {
  final int hour;
  final bool isSelected;
  final ValueChanged<int>? onHourSelected;

  const HourRow({
    Key? key,
    required this.hour,
    required this.isSelected,
    this.onHourSelected,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        onHourSelected?.call(hour);
      },
      child: Container(
        decoration: BoxDecoration(
          border: Border.all(
            color: isSelected ? Colors.black : Colors.transparent,
            width: 2.0,
          ),
        ),
        child: Row(
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
                    color: Colors.green,
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
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
