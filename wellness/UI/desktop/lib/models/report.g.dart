// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'report.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Report _$ReportFromJson(Map<String, dynamic> json) => Report(
      json['id'] as int,
      DateTime.parse(json['dateTo'] as String),
      DateTime.parse(json['dateFrom'] as String),
      (json['earnedMoney'] as num).toDouble(),
      json['memberShipTypeName'] as String?,
      json['memberShipTypeId'] as int,
      json['totalUsers'] as int?,
      DateTime.parse(json['timestamp'] as String),
    );

Map<String, dynamic> _$ReportToJson(Report instance) => <String, dynamic>{
      'id': instance.id,
      'dateTo': instance.dateTo.toIso8601String(),
      'dateFrom': instance.dateFrom.toIso8601String(),
      'earnedMoney': instance.earnedMoney,
      'memberShipTypeName': instance.memberShipTypeName,
      'memberShipTypeId': instance.memberShipTypeId,
      'totalUsers': instance.totalUsers,
      'timestamp': instance.timestamp.toIso8601String(),
    };
