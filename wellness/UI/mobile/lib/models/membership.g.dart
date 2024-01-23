// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'membership.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Membership _$MembershipFromJson(Map<String, dynamic> json) => Membership(
      json['id'] as int,
      json['expirationDate'] as String,
      json['startDate'] as String,
      json['status'] as bool,
      json['userName'] as String,
      json['memberShipTypeName'] as String,
    );

Map<String, dynamic> _$MembershipToJson(Membership instance) =>
    <String, dynamic>{
      'id': instance.id,
      'expirationDate': instance.expirationDate,
      'startDate': instance.startDate,
      'status': instance.status,
      'userName': instance.userName,
      'memberShipTypeName': instance.memberShipTypeName,
    };
