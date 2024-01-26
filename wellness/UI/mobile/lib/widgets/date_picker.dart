import 'package:flutter/material.dart';
import 'package:gap/gap.dart';
import 'package:intl/intl.dart';

class DatePickerWidget extends StatefulWidget {
  final Function(DateTime) onDateSelected;

  const DatePickerWidget({Key? key, required this.onDateSelected})
      : super(key: key);

  @override
  State<DatePickerWidget> createState() => _DatePickerWidgetState();
}

class _DatePickerWidgetState extends State<DatePickerWidget> {
  DateTime? selectedDate;

  @override
  void initState() {
    super.initState();
    selectedDate = DateTime.now();
  }

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: selectedDate!,
      firstDate: DateTime(2000),
      lastDate: DateTime(2101),
    );

    if (picked != null && picked != selectedDate) {
      setState(() {
        selectedDate = picked;
        widget.onDateSelected(picked);
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    final DateFormat formatter = DateFormat('dd.MM.yyyy');

    return Column(mainAxisAlignment: MainAxisAlignment.center, children: [
      SizedBox(
        width: double.infinity,
        child: ElevatedButton(
          onPressed: () => _selectDate(context),
          child: Text(
            selectedDate != null
                ? 'Odabrani datum: ${formatter.format(selectedDate!)}'
                : 'Odaberite datum',
          ),
        ),
      ),
      const Gap(20),
    ]);
  }
}
