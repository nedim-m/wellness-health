import 'package:json_annotation/json_annotation.dart';

part 'membership.g.dart';

@JsonSerializable()
class Membership {
  final int? id;
  final String? expirationDate;
  final String? startDate;
  final String? memberShipTypeName;

  factory Membership.fromJson(Map<String, dynamic> json) =>
      _$MembershipFromJson(json);

  Membership(
      this.id, this.expirationDate, this.startDate, this.memberShipTypeName);

  Map<String, dynamic> toJson() => _$MembershipToJson(this);
}
