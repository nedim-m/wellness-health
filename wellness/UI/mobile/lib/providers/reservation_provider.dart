import 'dart:convert';

import 'package:mobile/models/reservation.dart';
import 'package:mobile/providers/base_provider.dart';

class ReservationProvider extends BaseProvider<Reservation> {
  ReservationProvider() : super("Reservation");

  @override
  Reservation fromJson(data) {
    return Reservation.fromJson(data);
  }

  Future<dynamic> addReservation(
      int userId, String date, String time, int treatmentId) async {
    var url = "$baseUrl$endpoint";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token ?? ''); //zbog testa

    var jsonRequest = jsonEncode(<String, dynamic>{
      "userId": userId,
      "date": date,
      "time": time,
      "status": null,
      "treatmentId": treatmentId,
    });

    var response = await http!.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> cancelReservation(int id) async {
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token ?? ''); //zbog testa

    var jsonRequest = jsonEncode(<String, dynamic>{
      "status": false,
    });

    var response = await http!.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
