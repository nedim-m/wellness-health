import 'package:intl/intl.dart';

class CurrentDate {
  final DateFormat formatter = DateFormat('dd.MM.yyyy');
  late DateTime date;
  late String currentDate;

  CurrentDate() {
    date = DateTime.now();
    currentDate = formatter.format(date);
  }
}
