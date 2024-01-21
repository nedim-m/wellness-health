import 'package:json_annotation/json_annotation.dart';

part 'reservation.g.dart';

@JsonSerializable()
class Reservation {
  final int id;
  final String firstName;
  final String lastName;
  final String date;
  final String time;
  final String phone;
  final bool? status;
  final String treatment;

  Reservation(this.id, this.firstName, this.date, this.time, this.status,
      this.treatment, this.lastName, this.phone);

  factory Reservation.fromJson(Map<String, dynamic> json) =>
      _$ReservationFromJson(json);

  Map<String, dynamic> toJson() => _$ReservationToJson(this);
}
