// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'rating.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Rating _$RatingFromJson(Map<String, dynamic> json) => Rating(
      json['id'] as int,
      json['starRating'] as int,
      json['treatmentId'] as int,
      json['userId'] as int,
    );

Map<String, dynamic> _$RatingToJson(Rating instance) => <String, dynamic>{
      'id': instance.id,
      'starRating': instance.starRating,
      'treatmentId': instance.treatmentId,
      'userId': instance.userId,
    };
