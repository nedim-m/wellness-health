// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'reservation.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Reservation _$ReservationFromJson(Map<String, dynamic> json) => Reservation(
      json['id'] as int,
      json['firstName'] as String,
      json['lastName'] as String,
      json['date'] as String,
      json['time'] as String,
      json['status'] as bool,
      json['treatment'] as String,
    );

Map<String, dynamic> _$ReservationToJson(Reservation instance) =>
    <String, dynamic>{
      'id': instance.id,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'date': instance.date,
      'time': instance.time,
      'status': instance.status,
      'treatment': instance.treatment,
    };
