import 'package:json_annotation/json_annotation.dart';

part 'rating.g.dart';

@JsonSerializable()
class Rating {
  final int id;
  final int starRating;
  final int reservationId;

  factory Rating.fromJson(Map<String, dynamic> json) => _$RatingFromJson(json);

  Rating(this.id, this.starRating, this.reservationId);

  Map<String, dynamic> toJson() => _$RatingToJson(this);
}
