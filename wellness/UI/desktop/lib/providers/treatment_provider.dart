import 'dart:convert';

import '../models/treatment.dart';
import 'base_provider.dart';
import 'package:http/http.dart' as http;

class TreatmentProvider extends BaseProvider<Treatment> {
  TreatmentProvider() : super("Treatment");

  @override
  Treatment fromJson(data) {
    return Treatment.fromJson(data);
  }

  Future<dynamic> addTreatment(int treatmentTypeId, int categoryId,
      String description, int duration, double price, String picture) async {
    var url = "$baseUrl$endpoint";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "treatmentTypeId": treatmentTypeId,
      "categoryId": categoryId,
      "description": description,
      "duration": duration,
      "price": price,
      "picture": picture,
    });

    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }

  Future<dynamic> updateTreatment(int id, int treatmentTypeId, int categoryId,
      String description, int duration, double price, String picture) async {
    var url = "$baseUrl$endpoint/$id";
    var uri = Uri.parse(url);
    var headers = createJwtHeaders(token!);

    var jsonRequest = jsonEncode(<String, dynamic>{
      "treatmentTypeId": treatmentTypeId,
      "categoryId": categoryId,
      "description": description,
      "duration": duration,
      "price": price,
      "picture": picture,
    });

    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return (data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
