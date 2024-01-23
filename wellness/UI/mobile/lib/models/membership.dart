import 'package:json_annotation/json_annotation.dart';

part 'membership.g.dart';

@JsonSerializable()
class Membership {
  final int id;
  final String expirationDate;
  final String startDate;
  final bool status;
  final String userName;
  final String memberShipTypeName;
  Membership(this.id, this.expirationDate, this.startDate, this.status,
      this.userName, this.memberShipTypeName);

  factory Membership.fromJson(Map<String, dynamic> json) =>
      _$MembershipFromJson(json);

  Map<String, dynamic> toJson() => _$MembershipToJson(this);
}
