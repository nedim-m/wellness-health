// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'membership_type.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MembershipType _$MembershipTypeFromJson(Map<String, dynamic> json) =>
    MembershipType(
      json['id'] as int,
      json['name'] as String,
      json['description'] as String,
      (json['price'] as num).toDouble(),
      json['duration'] as int,
    );

Map<String, dynamic> _$MembershipTypeToJson(MembershipType instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
      'price': instance.price,
      'duration': instance.duration,
    };
