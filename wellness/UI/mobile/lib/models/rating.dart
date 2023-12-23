import 'package:json_annotation/json_annotation.dart';

part 'rating.g.dart';

@JsonSerializable()
class Rating {
  final int id;
  final int starRating;
  final int treatmentId;
  final int userId;

  Rating(this.id, this.starRating, this.treatmentId, this.userId);
  factory Rating.fromJson(Map<String, dynamic> json) => _$RatingFromJson(json);

  Map<String, dynamic> toJson() => _$RatingToJson(this);
}
