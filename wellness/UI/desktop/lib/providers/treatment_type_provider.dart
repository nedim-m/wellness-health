import '../models/treatment_type.dart';
import 'base_provider.dart';

class TreatmentTypeProvider extends BaseProvider<TreatmentType> {
  TreatmentTypeProvider() : super("TreatmentType");

  @override
  TreatmentType fromJson(data) {
    return TreatmentType.fromJson(data);
  }
}
