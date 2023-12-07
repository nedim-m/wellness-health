import 'package:mobile/models/treatment.dart';
import 'package:mobile/providers/base_provider.dart';

import 'dart:convert';

import 'package:http/http.dart' as http;

class TreatmentProvider extends BaseProvider<Treatment> {
  TreatmentProvider() : super("Treatment");

  final http.Client _httpClient = http.Client();

  @override
  Treatment fromJson(data) {
    return Treatment.fromJson(data);
  }

  Future<List<Treatment>> getAll() async {
    try {
      final response = await _httpClient.get(Uri.parse(baseUrl));
      if (response.statusCode == 200) {
        final List<dynamic> rawData = json.decode(response.body);
        final List<Treatment> data =
            rawData.map((json) => Treatment.fromJson(json)).toList();
        print("Data from server: $data");
        return data;
      } else {
        print("Error: ${response.statusCode}");
        throw Exception('Failed to load data');
      }
    } catch (e) {
      print("Error fetching data: $e");
      throw e;
    }
  }
}
