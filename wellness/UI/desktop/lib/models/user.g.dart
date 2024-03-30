// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

User _$UserFromJson(Map<String, dynamic> json) => User(
      json['id'] as int,
      json['firstName'] as String,
      json['lastName'] as String,
      json['email'] as String,
      json['userName'] as String,
      json['phone'] as String,
      json['status'] as bool,
      json['picture'] as String,
      json['role'] as String?,
      json['shiftTime'] as String?,
      json['roleId'] as int,
      json['shiftId'] as int,
      json['membershipType'] as String?,
    );

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'id': instance.id,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'email': instance.email,
      'userName': instance.userName,
      'phone': instance.phone,
      'status': instance.status,
      'picture': instance.picture,
      'role': instance.role,
      'shiftTime': instance.shiftTime,
      'roleId': instance.roleId,
      'shiftId': instance.shiftId,
      'membershipType': instance.membershipType,
    };
