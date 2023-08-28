// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'record.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Records _$RecordsFromJson(Map<String, dynamic> json) => Records(
      json['id'] as int,
      DateTime.parse(json['entryDate'] as String),
      DateTime.parse(json['leaveEntryDate'] as String),
      json['userId'] as int,
      json['firstName'] as String,
      json['lastName'] as String,
      json['phone'] as String,
      json['userName'] as String,
    );

Map<String, dynamic> _$RecordsToJson(Records instance) => <String, dynamic>{
      'id': instance.id,
      'entryDate': instance.entryDate.toIso8601String(),
      'leaveEntryDate': instance.leaveEntryDate.toIso8601String(),
      'userId': instance.userId,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'phone': instance.phone,
      'userName': instance.userName,
    };
