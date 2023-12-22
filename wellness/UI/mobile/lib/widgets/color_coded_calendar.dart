import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:intl/intl.dart';
import 'package:mobile/models/reservation.dart';
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
  List<Reservation> reservation = [];
  final DateFormat formatter = DateFormat('dd.MM.yyyy');

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  final ReservationProvider _reservationProvider = ReservationProvider();
  void _addReservation() async {
    if (selectedHour != null) {
      final provider = Provider.of<ReservationProvider>(context, listen: false);

      try {
        await provider.addReservation(
          3,
          formatter.format(widget.selectedDate),
          '$selectedHour:00',
          widget.treatmentId,
        );

        // ignore: use_build_context_synchronously
        showDialog(
          context: context,
          builder: (context) => AlertDialog(
            title: const Text('Uspješno'),
            content: const Text('Rezervacija uspješno dodana.'),
            actions: [
              TextButton(
                onPressed: () {
                  Navigator.pop(context);
                  fetchData();
                },
                child: const Text('OK'),
              ),
            ],
          ),
        );
      } catch (e) {
        // ignore: use_build_context_synchronously
        showDialog(
          context: context,
          builder: (context) => AlertDialog(
            title: const Text('Neuspješno'),
            content: const Text('Neuspjela rezervacija. Već ste rezervisali!'),
            actions: [
              TextButton(
                onPressed: () => Navigator.pop(context),
                child: const Text('OK'),
              ),
            ],
          ),
        );
      }
    }
  }

  Future<void> fetchData() async {
    List<Reservation> fetchedReservations = await _reservationProvider.get(
        filter: {
          'date': formatter.format(widget.selectedDate),
          'treatmentId': widget.treatmentId
        });

    setState(() {
      reservation = fetchedReservations;
    });
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
            reservations: reservation,
          ),
        ],
      ),
    );
  }
}

class CalendarHeader extends StatelessWidget {
  const CalendarHeader({Key? key}) : super(key: key);

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
  final List<Reservation> reservations;

  const CalendarGrid({
    Key? key,
    this.selectedHour,
    this.onHourSelected,
    this.addReservation,
    required this.reservations,
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
            reservations: reservations,
          ),
        const Gap(15),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [
            _buildLegendSquare(Colors.red),
            const SizedBox(width: 8),
            _buildLegendSquare(Colors.yellow),
            const SizedBox(width: 8),
            _buildLegendSquare(Colors.green),
          ],
        ),
        const Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround,
          children: [
            Text('Zauzeto'),
            SizedBox(width: 8),
            Text('Na čekanju'),
            SizedBox(width: 8),
            Text('Slobodno'),
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
  final List<Reservation> reservations;

  const HourRow({
    Key? key,
    required this.hour,
    required this.isSelected,
    this.onHourSelected,
    required this.reservations,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Reservation? currentReservation = reservations.firstWhere(
      (reservation) => reservation.time == '$hour:00',
      orElse: () => Reservation(
        0,
        '',
        '',
        '',
        '$hour:00',
        null,
        '',
      ),
    );

    Color containerColor;

    if (currentReservation.status != null) {
      if (currentReservation.status!) {
        containerColor = Colors.red;
      } else {
        containerColor = Colors.green;
      }
    } else {
      containerColor = Colors.yellow;
    }

    bool isTaken = reservations.any((reservation) {
      return reservation.time == '$hour:00';
    });

    if (!isTaken) {
      containerColor = Colors.green;
    }

    bool isClickable = containerColor == Colors.green;

    return GestureDetector(
      onTap: isClickable ? () => onHourSelected?.call(hour) : null,
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
                  decoration: BoxDecoration(
                    color: containerColor,
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
