import 'package:json_annotation/json_annotation.dart';

part 'reservation.g.dart';

@JsonSerializable()
class Reservation {
  final int id;
  final String firstName;
  final String lastName;
  final String date;
  final String time;
  final bool? status;
  final String treatment;
  final int treatmentId;

  Reservation(this.id, this.firstName, this.lastName, this.date, this.time,
      this.status, this.treatment, this.treatmentId);
  factory Reservation.fromJson(Map<String, dynamic> json) =>
      _$ReservationFromJson(json);

  Map<String, dynamic> toJson() => _$ReservationToJson(this);
}
