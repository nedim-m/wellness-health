import 'package:json_annotation/json_annotation.dart';

part 'report.g.dart';

@JsonSerializable()
class Report {
  final int id;
  final DateTime dateTo;
  final DateTime dateFrom;
  final double earnedMoney;
  final String memberShipTypeName;

  factory Report.fromJson(Map<String, dynamic> json) => _$ReportFromJson(json);

  Report(this.id, this.dateTo, this.dateFrom, this.earnedMoney,
      this.memberShipTypeName);

  Map<String, dynamic> toJson() => _$ReportToJson(this);
}
