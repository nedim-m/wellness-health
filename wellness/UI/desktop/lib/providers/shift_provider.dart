import 'package:desktop/models/shift.dart';
import 'package:desktop/providers/base_provider.dart';

class ShiftProvider extends BaseProvider<Shift> {
  ShiftProvider() : super("Shift");

  @override
  Shift fromJson(data) {
    return Shift.fromJson(data);
  }
}
