import 'package:json_annotation/json_annotation.dart';

part 'shift.g.dart';

@JsonSerializable()
class Shift {
  final int id;
  final String name;
  final String workingHours;

  factory Shift.fromJson(Map<String, dynamic> json) => _$ShiftFromJson(json);

  Shift(this.id, this.name, this.workingHours);

  Map<String, dynamic> toJson() => _$ShiftToJson(this);
}
