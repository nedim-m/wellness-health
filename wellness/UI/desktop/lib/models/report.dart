import 'package:json_annotation/json_annotation.dart';

part 'report.g.dart';

@JsonSerializable()
class Report {
  final int id;
  final DateTime dateTo;
  final DateTime dateFrom;
  final double earnedMoney;
  final String? memberShipTypeName;
  final int memberShipTypeId;
  final int? totalUsers;

  factory Report.fromJson(Map<String, dynamic> json) => _$ReportFromJson(json);

  Report(this.id, this.dateTo, this.dateFrom, this.earnedMoney,
      this.memberShipTypeName, this.memberShipTypeId, this.totalUsers);

  Map<String, dynamic> toJson() => _$ReportToJson(this);
}
