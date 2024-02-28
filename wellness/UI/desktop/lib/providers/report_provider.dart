import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:desktop/models/report.dart';
import 'package:desktop/providers/base_provider.dart';

class ReportProvider extends BaseProvider<Report> {
  ReportProvider() : super("Report");

  @override
  Report fromJson(data) {
    return Report.fromJson(data);
  }

  Future<Report> add(
      DateTime dateTo, DateTime dateFrom, int membershipTypeId) async {
    var url = "$baseUrl$endpoint";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    String dateToString = dateTo.toString();
    String dateFromString = dateFrom.toString();

    var jsonRequest = jsonEncode(<String, dynamic>{
      "dateTo": dateToString,
      "dateFrom": dateFromString,
      "membershipTypeId": membershipTypeId
    });

    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<Map<String, dynamic>> getNumUsers() async {
    var url = "$baseUrl$endpoint/report-users";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);

      return data;
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<Map<String, dynamic>> getNumMemberships() async {
    var url = "$baseUrl$endpoint/report-memberships";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<Map<String, dynamic>> getNumReservations() async {
    var url = "$baseUrl$endpoint/report-reservations";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return data;
    } else {
      throw Exception("Unknown error");
    }
  }
}
